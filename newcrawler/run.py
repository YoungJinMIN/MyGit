from selenium import webdriver as wd
from bs4 import BeautifulSoup as bs
from selenium.webdriver.common.by import By
# 명시적 대기를 위해
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
import pymysql as my
from DbMgr import DBHelper as Db
import time
from Tour import TourInfo
import sys

main_url = 'http://tour.interpark.com/'
keyword = '로마'

tour_list = []

driver = wd.Chrome(executable_path='chromedriver.exe')


driver.get(main_url)


time.sleep(2)
driver.find_element_by_id('SearchGNBText').send_keys(keyword)
driver.find_element_by_css_selector('button.search-btn').click()

try:
    element = WebDriverWait(driver, 10).until(
        # 지정한 한개 요소가 올라오면 웨이트 종료
        EC.presence_of_element_located( (By.CLASS_NAME, 'oTravelBox') )
    )
except Exception as e:
    print(' 오류 발생 ', e)


driver.implicitly_wait(10)   
driver.find_element_by_css_selector('.oTravelBox>.boxList>.moreBtnWrap>.moreBtn').click()


for page in range(1,2): #7):
    try:
        # 자바스크립트 구동하기
        driver.execute_script("searchModule.SetCategoryList(%s, '')" % page)
        time.sleep(2)
        ##################################################################
        # 여러 사이트에서 정보를 수집할 경우 공통 정보 정의 단계 필요
        # 상품명, 코멘트, 기간1, 기간2, 가격, 평점, 썸네일, 링크(상품상세정보)
        boxItems = driver.find_elements_by_css_selector('.oTravelBox>.boxList>li')
        # 상품 하나 하나 접근
        for li in boxItems:
            # 이미지를 링크값을 사용할 것인가? 직접다운로드 해서 우리 서버에 업로드(ftp) 할 것인가?
            print('썸네일', li.find_element_by_css_selector('img').get_attribute('src'))
            print('링크', li.find_element_by_css_selector('a').get_attribute('onclick'))
            print('상품명', li.find_element_by_css_selector('h5.proTit').text)
            print('코멘트', li.find_element_by_css_selector('.proSub').text)
            print('가격', li.find_element_by_css_selector('.proPrice').text) 
            area = ''
            for info in li.find_elements_by_css_selector('.info-row .proInfo'):
                print(info.text)   
            print('='*100)
            # 데이터 모음
            # li.find_elements_by_css_selector('.info-row .proInfo')[1].text
            # 데이터가 부족하거나 없을수도 있으므로 직접 인덱스로 표현은 위험성이 있음
            obj = TourInfo(
                li.find_element_by_css_selector('h5.proTit').text,
                li.find_element_by_css_selector('.proPrice').text,
                li.find_elements_by_css_selector('.info-row .proInfo')[1].text,
                li.find_element_by_css_selector('a').get_attribute('onclick'),
                li.find_element_by_css_selector('img').get_attribute('src')
            )
            tour_list.append(obj)
    except Exception as e1:
        print('오류', e1)
    
print(tour_list, len(tour_list))

'''
# 동작안됨
# 수집한 정보 개수를 루프 => 페이지 방문 => 콘텐츠 획득(상품상세정보) => 디비
for tour in tour_list:
    # tour => TourInfo
    print(type(tour))
    # 링크 데이터에서 실데이터 획득
    arr = tour.link.split(',')
    if arr:
        # 대체
        link = arr[0].replace('searchModule.OnClickDetail(','')
        # 슬라이싱 => 앞에 ', 뒤에 ' 제거
        detail_url = link[1:-1]
        # 상세 페이지 이동 : URL 값이 완성된 형태인지 확인(http~)
        driver.get(detail_url)
        time.sleep(1)
        #pip install bs4
        # 현재 페이지를 beautiful soup의 DOM으로 구성
        soup = bs(driver.page_source, 'html.parser')
        # 현재 상세 정보 페이지에서 스케쥴 정보를 획득
        #data = soup.select('.schedule-all')
        data = soup.select('.tip-cover')

        print(type(data), len(data))
        # 디비 입력 => pip install pymysql
        content_final = ''
        for c in data[0].contents:
            content_final = str(c)

        # 콘텐츠 내용에 따라 전처리 => data[0].contents
        db.db_insertCrawlingData(
            tour.title,
            tour.price,
            tour.area,
            )


# 종료
driver.close()
driver.quit()
sys.exit()
'''