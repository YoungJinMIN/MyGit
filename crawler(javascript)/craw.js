const webdriver = require('selenium-webdriver'),
    By = webdriver.By,
    until = webdriver.until;
//const time = require('time');
function range(start, end) {
    if(start === end) return [start];
    return [start, ...range(start + 1, end)];
}

    const driver = new webdriver.Builder().forBrowser('chrome').build();
    driver.get('https://land.naver.com/article/divisionInfo.nhn?rletTypeCd=A01&tradeTypeCd=&hscpTypeCd=A01&cortarNo=1168000000&articleOrderCode=&cpId=&minPrc=&maxPrc=&minWrrnt=&maxWrrnt=&minLease=&maxLease=&minSpc=&maxSpc=&subDist=&mviDate=&hsehCnt=&rltrId=&mnex=&siteOrderCode=&cmplYn=');
/*
    driver.findElement(By.css('tbody>tr')).getText().then(function(el) {
        console.log(el);
    })
*/
    //driver.findElement(By.xpath("//a[@href='javascript:nhn.article.common.paging(4)']")).click();

for(page in range(1,5)) {
    page++;
    console.log(page);
    
    
    driver.wait(until.elementLocated(By.css('.paginate')), 20000).then(function(){
        driver.findElement(By.css("a[href='javascript:nhn.article.common.paging("+page+")']")).click();
    });
}

//driver.findElement(By.css('tbody>tr>.align_l>div>a')).click();
   // el.findElement(By.xpath("//a[@href='#']")).click();  
   //driver.findElement(By.xpath("//a[@href='#']")).click();

    /*
    driver.findElement(By.css('.info_section')).getText().then(function(el) {
        console.log(el);
    })
    */