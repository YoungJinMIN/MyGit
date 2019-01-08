# 상품 정보를 담는 클래스
class Items:
    # 멤버변수 (실제 컬럼보다는 작게 세팅)
    name    = ''
    price   = ''
    photo   = ''
    
    # 생성자
    def __init__(self, name, price, photo):
        self.name    = name
        self.price   = price
        self.photo   = photo
        
        