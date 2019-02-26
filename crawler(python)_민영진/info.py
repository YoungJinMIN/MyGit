# 상품 정보를 담는 클래스
class HomeInfo:
    # 멤버변수 (실제 컬럼보다는 작게 세팅)
    deal   = ''
    type_of   = ''
    check_date    = ''
    house_name    = ''
    area     = ''
    floor = ''
    price = ''
    contect = ''
    link = ''
    # 생성자
    def __init__(self, deal, type_of, check_date, house_name, area, floor, price, contect, link):
        self.deal       = deal
        self.type_of    = type_of
        self.check_date = check_date
        self.house_name = house_name
        self.area       = area
        self.floor      = floor
        self.price      = price
        self.contect    = contect
        self.link       = link

        