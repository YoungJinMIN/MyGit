<!doctype html>
<html>
    <head>
        <h2> 쿠폰 코드 발행 페이지 </h2>
    </head>
    <body>
    <form method='post' action='coupon_make.php'>
            <div>
                <label for='prefix'> prefix </label>
                <input type='text' name='prefix' placeholder='3자리 문자,숫자'/>
            </div>
            
            <div class='button'>
                <button type='submit'> 쿠폰생성 </button>
            </div>
        </form>        
    </body>
</html>