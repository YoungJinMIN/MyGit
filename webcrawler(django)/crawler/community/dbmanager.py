import pymysql

class DBHelper:
    '''
    멤버변수 : 커넥션
    '''
    conn = None
    '''
    생성자
    '''
    def __init__(self):
        self.db_init()
    '''
    멤버 함수
    '''
    def db_init(self):
        self.conn = pymysql.connect(
                             host='localhost',
                             user='root',
                             password='111111',
                             db='webcrawler',
                             charset='utf8',
                             cursorclass=pymysql.cursors.DictCursor)
    def db_free(self):
        if self.conn:
            self.conn.close()
    # 검색 키워드 가져오기 => 웹에서 검색
    def db_selectKeyword(self):
        # 커서 오픈
        # with => 닫기 처리를 자동으로 함 => I/O에서 많이 사용
        with self.conn.cursor() as cursor:
            sql = "select * from product"
            cursor.execute(sql)
            rows = cursor.fetchall()
            print(rows[1])
        return rows
        
    def db_insertCrawlingData(self, name, price, photo):
        with self.conn.cursor() as cursor:
            sql = '''
            insert into `product` (name, price, photo)
            values(%s,%s,%s)
            '''
            cursor.execute(sql, (name, price, photo))
        self.conn.commit()

'''
if __name__=='__main__':
    db = DBHelper()
    print(db.db_selectKeyword())
    print(db.db_insertCrawlingData('1','2','3'))
    db.db_free()
'''