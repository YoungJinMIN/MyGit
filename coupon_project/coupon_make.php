<?php

function RandomString($code_length) {
    session_start(); // 세션
    include ("connect_db.php"); // DB접속
    $j=0;
    $keys = array_merge(range(0,9), range('a', 'z')); // 문자와 숫자 병합
    $prefix = $_POST['prefix']; 
    $key[] = "";
    $num = 10;              // 10만개 
    if(strlen($prefix) != 3) {        //prefix 입력값에 대한 예외처리
        echo "<script>window.alert('3글자만 가능합니다.');</script>";
        echo "<script>location.href='coupon_create.php';</script>";
    } else {
        for ($i=0; $i < $num; $i++) {    // num 갯수 만큼 쿠폰 생성
            $key[$i] .= $prefix;
            for($j=0; $j < $code_length; $j++) {  // 병합한 keys에서 랜덤한 값 1개 추출 length만큼 진행
                $key[$i] .= $keys[mt_rand(0, count($keys) - 1)]; 
            }
        }
        for($i = 0; $i<count($key); $i++) {       // 추출한 쿠폰값 DB에 저장
            if($i%10 == 0){
                $sql = "insert into coupon(coupon_code,use_date,use_user,group_num) values('$key[$i]','','','')";
            } else {
                $sql = "insert into coupon(coupon_code,use_date,use_user,group_num) values('$key[$i]','','','')";
            }
            $result = mysqli_query($con, $sql);
            if($result === false) {
                echo mysqli_error($conn);
            }
        }
        return "<script>location.href='coupon_list.php';</script>";  //list 페이지로 이동
    }
}

$code_length = 13;            
echo RandomString($code_length); // prefix를 제외한 13을 인자로 전달

?>