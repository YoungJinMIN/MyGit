from selenium import webdriver as wd
from selenium.webdriver.common.by import By
import time
from info import HomeInfo
import sys
import csv

# 접속할 사이트 url
main_url = 'https://land.naver.com/article/divisionInfo.nhn?rletTypeCd=A01&tradeTypeCd=&hscpTypeCd=A01&cortarNo=1168000000&articleOrderCode=&cpId=&minPrc=&maxPrc=&minWrrnt=&maxWrrnt=&minLease=&maxLease=&minSpc=&maxSpc=&subDist=&mviDate=&hsehCnt=&rltrId=&mnex=&siteOrderCode=&cmplYn='
# 정보 담을 배열
info_list = []
driver = wd.Chrome(executable_path='chromedriver.exe')
# 사이트 접근
driver.get(main_url)
# 암묵적 대기
driver.implicitly_wait(10)   
# 10페이지 까지 접근하면서 정보 담는 루프
for page in range(1,11):
    try:
        time.sleep(2)
        i = 0
        info = driver.find_elements_by_css_selector('tbody>tr')
        
        while i <= len(info):
            if i % 2 == 0:                
                obj = HomeInfo(
                    info[i].find_element_by_css_selector('.sale_type').text,
                    info[i].find_element_by_css_selector('.sale_type2').text,
                    info[i].find_element_by_css_selector('td>.inner_mark').text,
                    info[i].find_element_by_css_selector('td>div>a').get_attribute('title'),
                    info[i].find_element_by_css_selector('.num>.inner').text,
                    info[i].find_element_by_css_selector('.num2>.inner').text,
                    info[i].find_element_by_css_selector('.align_r').text,
                    info[i].find_element_by_css_selector('.contact').text,
                    info[i].find_element_by_css_selector('.name>div>.btn_naverlink>a').get_attribute('href')
                )
                info_list.append(obj)
                i = i + 1
            else:
                i = i + 1
                if i==len(info):
                    break
                continue

        driver.find_element_by_xpath("//a[@class='NP=r:"+str(page+1)+"']").click()        
    except Exception as e1:
        print('오류 : ', e1)

# 배열에 있는 모든 상세페이지 접근후 매물명 가져오기
index = 0
for temp in info_list:
    detail_url = temp.link
    driver.get(detail_url)
    
    detail_name = driver.find_element_by_css_selector('.ellipsis').text
    temp.house_name = detail_name
    
    index = index + 1
    time.sleep(2)

# 파일에 정보 담기
f = open('info.csv','w', encoding='utf-8',newline='')
csv_writer = csv.writer(f, delimiter='/')    
csv_writer.writerow(['거래','종류','확인일자','매물명','면적','층','매물가(만원)','연락처','링크'])

for temp in info_list:
    csv_writer.writerow([temp.deal, temp.type_of, temp.check_date, temp.house_name, temp.area, temp.floor, temp.price, temp.contect, temp.link])    

# 종료
f.close()
driver.close()
driver.quit()
sys.exit()
