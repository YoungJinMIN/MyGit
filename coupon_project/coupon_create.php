<!doctype html>
<?php
    session_start();
    $id = $_SESSION['id'];
    if($id != 'admin'){             // admin 계정만 접근가능 예외처리
        echo "<script>window.alert('접근 할 수 없습니다.');</script>";
        echo "<script>location.href='coupon_use.php';</script>";
    }
?>
<html>
    <head>
        <h2> 쿠폰 코드 발행 페이지 </h2>
    </head>
    <body>
    
    <form method='post' action='coupon_make.php'>  
        <div>
            <a href='coupon_list.php'>쿠폰 목록 페이지</a>
            <a href='coupon_use.php'>쿠폰 사용 페이지</a>
        </div>        
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