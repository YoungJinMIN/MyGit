<?php

session_start(); // 세션
include ("connect_db.php"); // DB접속

$coupon_code = $_POST['coupon_code']; // 쿠폰번호 
   
$query = "select * from coupon where coupon_code='$coupon_code'";
$result = mysqli_query($con, $query); 
$row = mysqli_fetch_array($result); // DB 테이블에서 레코드를 배열로 가져오기

if($coupon_code==$row['coupon_code'] && $row['use_user'] ==''){ // 쿠폰 사용 확인
    echo "<script>window.alert('사용 가능한 쿠폰번호 입니다.');</script>";
    echo "<script>location.href='coupon_use.php';</script>";
} else if($coupon_code!=$row['coupon_code']) {
    echo "<script>window.alert('쿠폰번호를 잘못 입력하셨습니다.');</script>";
} else { 
    echo "<script>window.alert('이미 사용한 쿠폰번호 입니다.');</script>"; 
    echo "<script>location.href='coupon_use.php';</script>";
}
?>