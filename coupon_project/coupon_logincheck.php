<?php

session_start(); // 세션
include ("connect_db.php"); // DB접속

$id = $_POST['id']; // 아이디 
$pw = $_POST['pw']; // 패스워드
   
$query = "select * from user where id='$id' and pw='$pw'";
$result = mysqli_query($con, $query); 
$row = mysqli_fetch_array($result);     // DB 테이블에서 레코드를 배열로 가져오기

if($id==$row['id'] && $pw==$row['pw']){ // id와 pw가 맞다면 login
    $_SESSION['id']=$row['id'];
    $_SESSION['name']=$row['name'];

    if($id == 'admin')  // admin은 생성페이지로 나머지는 사용페이지로 이동
        echo "<script>location.href='coupon_create.php';</script>";
    else
        echo "<script>location.href='coupon_use.php';</script>";

}else{ // id 또는 pw가 다르다면 login 폼으로

   echo "<script>window.alert('잘못된 아이디 또는 비빌번호 입니다');</script>";
   echo "<script>location.href='coupon_login.php';</script>";

}
