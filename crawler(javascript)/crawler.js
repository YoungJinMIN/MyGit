const webdriver = require('selenium-webdriver'),
    By = webdriver.By,
    until = webdriver.until;
//const time = require('time');

    const driver = new webdriver.Builder().forBrowser('chrome').build();
    driver.get('http://tour.interpark.com/');
    
    driver.sleep(20000);
   
    driver.findElement(By.id('SearchGNBText')).sendKeys('로마');
    driver.findElement(By.css('button.search-btn')).click();
    
    driver.manage().timeouts().implicitlyWait(5000);
    //driver.wait(until.elementLocated(By.css('.oTravelBox')), 10000);
    driver.findElement(By.css('.oTravelBox>.boxList>.moreBtnWrap>.moreBtn')).click();
    
   
    
    
    
    
    
    //
    //driver.quit();