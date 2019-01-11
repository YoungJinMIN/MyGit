<?php
    session_start();
    $id = $_SESSION['id'];

    if($id != 'admin'){             // admin 계정만 접근가능 예외처리
        echo "<script>window.alert('접근 할 수 없습니다.');</script>";
        echo "<script>location.href='coupon_use.php';</script>";
    }
?>
<!doctype html>
<html>
    <body>
    <article class="coupon_list">
        <h2> 쿠폰 리스트 </h2>
        <div>    
            <a href='coupon_create.php'>쿠폰 생성 페이지</a>
            <a href='coupon_use.php'>쿠폰 사용 페이지</a>
        </div>
        <br>
<?php
    include ("connect_db.php");  // DB접속
?>
<?php
    //DB 데이터 수 추출
    $data = mysqli_query($con, "select no from coupon order by no desc"); 
    $num = mysqli_num_rows($data);
    $list = 10;
    $block = 3;
    // 총페이지
    $pageNum = ceil($num/$list);
    $blockNum = ceil($pageNum/$block);
    $nowBlock = ceil($page/$block);

    $s_page = ($nowBlock*$block) - ($block -1);
    if($s_page <=1) { //처음페이지 설정
        $s_page=1;
    }
    $e_page = $nowBlock*$block;
    if(pageNum <= $e_page) {  // 시작페이지와 종료 페이지가 총 페이지의 최소, 최대 범위 넘지않게 하기위한 조건
        $e_page = $pageNum;
    }
    $page = ($_GET['page'])?$_GET['page']:1;    // page변수 설정해서 get으로 전달
    
    for($p=$s_page;$p<=$e_page;$p++) {    // 노출되는 페이징 넘버 생성
?>  
        <a href="<?=$PHP_SELP?>?page=<?=$p?>"><?=$p?></a>
<?php
    }
?>
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

            $real_data = mysqli_query($con,"select * from coupon order by no desc limit $s_point, $list"); //DB 테이블 가져오기

            for($i=1;$i<=$num;$i++) {   //DB 테이블에서 레코드 리턴해서 화면에 출력
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
                if($fetch == false) {   //데이터 없으면 종료
                    exit;
                }
            }
        ?>
            </tbody>
        </table>
    </article>
    </body>
</html>