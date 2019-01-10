<?php

//session_start(); // 세션
//include ("connect_db.php"); // DB접속

function RandomString($length) {
    session_start(); // 세션
    include ("connect_db.php"); // DB접속

    $keys = array_merge(range(0,9), range('a', 'z'));
    $prefix = $_POST['prefix']; 
    print "prefix : $prefix\n";
    print "<br>";

    $key[] = "";
    for ($i=0; $i < 10; $i++) {
        $key[$i] .= $prefix;
        for($j=0; $j < $length; $j++) {
            $key[$i] .= $keys[mt_rand(0, count($keys) - 1)];
        }
        //여기에 쿠폰 출력
    }

    for($i = 0; $i<count($key); $i++) {
        print "coupon : $key[$i]\n";
        print "<br>";
        $sql = "insert into coupon(coupon_code,use_date,use_user,group_num) values('$key[$i]','','','')";
        $result = mysqli_query($con, $sql);
        if($result === false) {
            echo mysqli_error($conn);
        }
        //if($con->query($sql) === TRUE) {}
    }
    
    //$sql = "insert into coupon(coupon_code,user_date,use_user,group_num) values($key[$i],'','','')";
  
    
}

echo RandomString(13);

?>