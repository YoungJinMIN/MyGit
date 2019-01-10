<?php

    session_start(); // 세션
    include ("connect_db.php"); // DB접속
?>
<?php
    $data = mysqli_query($con, "select no from coupon order by no desc");
    $num = mysqli_num_rows($data);

    $list = 10;
    $block = 3;
    
    $pageNum = ceil($num/$list);
    $blockNum = ceil($pageNum/$block);
    $nowBlock = ceil($page/$block);

    $s_page = ($nowBlock*$block) - ($block -1);
    if($s_page <=1) {
        $s_page=1;
    }
    $e_page = $nowBlock*$block;
    if(pageNum <= $e_page) {
        $e_page = $pageNum;
    }
    $page = ($_GET['page'])?$_GET['page']:1;
    
    for($p=$s_page;$p<=$e_page;$p++) {
?>  
        <a href="<?=$PHP_SELP?>?page=<?=$p?>"><?=$p?></a>
<?php
    }
?>

<!doctype html>
<html>
    <body>
    <article class="coupon_list">
        <h2> 쿠폰 리스트 </h2>
        
        <div>
            <a href="<?=$PHP_SELP?>?page=<?=$s_page-1?>">이전</a>
            <a href="<?=$PHP_SELP?>?page=<?=$s_page+1?>">다음</a>
        </div>
        <table>
            <thead>
                <th scope="col" class="no">No</th>
                <th scope="col" class="coupon_code">쿠폰 번호</th>
                <th scope="col" class="use_date">사용날짜</th>
                <th scope="col" class="use_user">사용자</th>
                <th scope="col" class="group_num">그룹</th>
            </thead>
            <tbody>
        <?php
            $s_point = ($page-1) * $list;

            $real_data = mysqli_query($con,"select * from coupon order by no desc limit $s_point, $list");

            for($i=1;$i<=$num;$i++) {
                //$fetch = mysqli_fetch_array($real_data);
                $fetch = mysqli_fetch_assoc($real_data);

        ?>

            <tr>
                <td class="no"><?php echo $fetch[no]?></td>                
                <td class="coupon_code"><?php echo $fetch[coupon_code]?></td>                
                <td class="use_date"><?php echo $fetch[use_date]?></td>                
                <td class="use_user"><?php echo $fetch[use_user]?></td>
                <td class="group_num"><?php echo $fetch[group_num]?></td>
            </tr>
        <?php
                if($fetch == false) {
                    exit;
                }
            }
        ?>
            </tbody>
        </table>
    </article>
    </body>
</html>