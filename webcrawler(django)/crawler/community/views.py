from django.shortcuts import render
from community.forms import *
from community.models import *
from selenium import webdriver as wd
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from community.dbmanager import DBHelper as Db
from community.items import Items
import pymysql
import time

# Create your views here.
def search(request):
    if request.method == 'POST':
        form = Form(request.POST)
        if form.is_valid():
            
            keyword = request.POST['name'];
            
            product = crawling(keyword)

            args={'product':product}    

            return render(request, 'list.html',args)

           # driver.close()
           # driver.quit()
           # sys.exit()    
            
    else:
            form = Form()

    return render(request, 'search.html', {'form':form})
    


def list(request):
        prodectList = Product.objects.all()
        return render(request, 'list.html', {'prodectList':prodectList})


def crawling(keyword):
        main_url = 'http://www.11st.co.kr/'
        db = Db()
        product = []        
        driver = wd.Chrome('chromedriver')
        driver.get(main_url) # 브라우저 실행
        time.sleep(2) 
        driver.find_element_by_id('AKCKwd').send_keys(keyword) # 검색창 찾아서 키워드 입력
        driver.find_element_by_css_selector('button.btn_search').click() # 검색버튼 클릭 

        try:
                element = WebDriverWait(driver, 10).until(
                # 지정한 한개 요소가 올라오면 웨이트 종료
                EC.presence_of_element_located( (By.CLASS_NAME, 'total_listing_wrap') )
                )
        except Exception as e:
                print(' 오류 발생 ', e)

                driver.implicitly_wait(10)    


           
        items = driver.find_elements_by_css_selector('.total_listing_wrap>.tt_listbox>li')

        for li in items:
                print('제품명 : ', li.find_element_by_css_selector('p.info_tit').text)
                print('가격 : ', li.find_element_by_css_selector('.list_price').text)
                print('썸네일 : ', li.find_element_by_css_selector('img').get_attribute('data-original'))
                
                db.db_insertCrawlingData(
                        li.find_element_by_css_selector('p.info_tit').text,
                        li.find_element_by_css_selector('.list_price').text,
                        li.find_element_by_css_selector('img').get_attribute('data-original')
                )
                
                obj = Items(
                        li.find_element_by_css_selector('p.info_tit').text,
                        li.find_element_by_css_selector('.list_price').text,
                        li.find_element_by_css_selector('img').get_attribute('data-original')
                )
                product.append(obj)

        return product