<!doctype html>
<html>
    <head>
        <h2> 쿠폰 코드 사용 페이지 </h2>
    </head>
    <body>
    <div>
        <a href='coupon_create.php'>쿠폰 생성 페이지</a>
        <a href='coupon_list.php'>쿠폰 목록 페이지</a>
    </div>
    <form method='post' action='coupon_usecheck.php'>
    
            <div>
                <label for='coupon_code'> Coupon code </label>
                <input type='text' name='coupon_code'/>
            </div>
            <div class='button'>
                <button type='submit'> 입력 </button>
            </div>
    </form>
    </body>
</html>