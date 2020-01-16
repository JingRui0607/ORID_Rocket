﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCreateORID.aspx.cs" Inherits="ORID_api_Rocket.TestCreateORID" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>火箭隊｜學員日記填寫表單</title>
    <!-- <meta content="width=device-width, initial-scale=1.0" name="viewport"> -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">

    <meta property="og:title" content="六角學院｜火箭隊軟體工程師培訓營">
    <meta property="og:description" content="火箭隊軟體工程師培訓計畫｜與您一同搭造火箭，讓您的人生一飛沖天">
    <meta property="og:image" content="http://register.rocket-coding.com/img/fb.jpg">

    <meta property="fb:app_id" content="113926539963626">
    <meta property="og:site_name" content="六角學院｜火箭隊軟體工程師培訓營">
    <meta property="og:locale" content="zh_TW">
    <!-- <meta property="og:url" content="http://register.rocket-coding.com/"> -->
    <meta property="og:type" content="website">
    <link rel="icon" href="img/favicon.png">

    <meta content="http://register.rocket-coding.com/img/fb.png" name="image">
    <meta content="火箭隊軟體工程師培訓計畫｜與您一同搭造火箭，讓您的人生一飛沖天" name="description">
    <meta content="六角學院" name="author">
    <link rel="stylesheet" href="css/all.css">
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
        <div class="logo">
            <img src="img/logo.png" alt="">
            <h1><span>｛ 火箭隊學員</span> 學習日記 <span> ｝</span></h1>
        </div>
        <div class="bgItme">
            <img class="man" src="img/man.png" alt="">
            <!-- <img class="moon" src="img/moon.png" alt=""> -->
            <img class="rocket" src="img/rocket.png" alt="">
        </div>
        <div class="form">
            <form action="" method="post" target="hide_iframe">
                <div class="form__group">
                    <label for="">姓名</label>
                    <div class="select">
                        <select name="姓名" id="">
                            <option disabled selected hidden>請選擇</option>
                            <option value="江宜蓁">宜蓁</option>
                            <option value="Chita">Chita</option>
                            <option value="Mike">Mike</option>
                        </select>
                    </div>
                </div>
                <div class="form__group">
                    <label for="">【週一填寫】您本週的目標是？</label>
                    <textarea id="editor01" name="editor01" rows="3" required></textarea>
                </div>
                <div class="form__group">
                    <label for="">您覺得距離本週五前訂定的目標，已達成多少？</label>
                    <div class="form__progress">
                        <div class="degree">
                            <em></em>
                        </div>
                        <span>10%<input type="radio" name="ok" value="10" required></span>
                        <span>20%<input type="radio" name="ok" value="20" required></span>
                        <span>30%<input type="radio" name="ok" value="30" required></span>
                        <span>40%<input type="radio" name="ok" value="40" required></span>
                        <span>50%<input type="radio" name="ok" value="50" required></span>
                        <span>60%<input type="radio" name="ok" value="60" required></span>
                        <span>70%<input type="radio" name="ok" value="70" required></span>
                        <span>80%<input type="radio" name="ok" value="80" required></span>
                        <span>90%<input type="radio" name="ok" value="90" required></span>
                        <span>100%<input type="radio" name="ok" value="100" required></span>
                    </div>
                </div>
                <div class="form__group">
                    <label for="">您覺得今天整體心情如何？</label>
                    <div class="form__img">
                        <div class="form__group">
                            <input type="radio" name="mood" value="1" required>
                            <img src="img/mood/01.svg">
                            <label for="mood">非常不開心</label>
                        </div>
                        <div class="form__group">
                            <input type="radio" name="mood" value="2" required>
                            <img src="img/mood/02.svg" alt="">
                            <label for="mood">不開心</label>
                        </div>
                        <div class="form__group">
                            <input type="radio" name="mood" value="3" required>
                            <img src="img/mood/03.svg" alt="">
                            <label for="mood">普通</label>
                        </div>
                        <div class="form__group">
                            <input type="radio" name="mood" value="4" required>
                            <img src="img/mood/04.svg" alt="">
                            <label for="mood">開心</label>
                        </div>
                        <div class="form__group">
                            <input type="radio" name="mood" value="5" required>
                            <img src="img/mood/05.svg" alt="">
                            <label for="mood">非常開心</label>
                        </div>
                    </div>
                </div>
                <div class="form__group">
                    <label for="">【學習歷程描述】請紀錄你今天的投入中過程學習了什麼，完成哪些項目？遭遇到什麼困難？</label>
                    <textarea id="editor02" name="" rows="3" required></textarea>
                </div>
                <div class="form__group">
                    <label for="">【心情寫照】今天的情緒高峰與低峰是如何呢？</label>
                    <textarea id="editor03" name="" rows="3" required></textarea>
                </div>
                <div class="form__group">
                    <label for="">【每日獲得】您今天學到了什麼？今天獲得最重要的領悟是？</label>
                    <textarea id="editor04" name="" rows="3" required></textarea>
                </div>
                <div class="form__group">
                    <label for="">【明日行動】您會如何用一句話形容今天的投入？有哪些工作是明天需要繼續努力的？</label>
                    <textarea id="editor05" name="" rows="3" required></textarea>
                </div>
                <div class="form__group">
                    <label for="">【週五填寫】您覺得本週訂定的目標是否適合？是否有改善的空間？</label>
                    <textarea id="editor06" name="" rows="3" required></textarea>
                </div>
                <button type="submit" class="form__btn">OK</button>
            </form>
            <iframe id="hide_iframe" name="hide_iframe" style="display:none;"></iframe>
        </div>
        <div id="particles-js"></div>
    </div>
    <footer>
        Copyright © 2019 HexSchool.All rights reserved.
    </footer>

    </form>
</body>
</html>
<script src="js/particles.min.js"></script>

<script src="js/ckeditor.js"></script>
<script src="js/sample.js"></script>
<script src="js/star.js"></script>
<script src="js/script.js"></script>
<script>
    initSample();
</script>
<input type="hidden" name="hiddenToken" id="hiddenToken" value="" >

<script src="https://www.google.com/recaptcha/api.js?render=6LdGz78UAAAAAD6K2raruEUQnSY11kcEsg2Ng-_X"></script>
<script>
    grecaptcha.ready(function () {
        grecaptcha.execute('6LdGz78UAAAAAD6K2raruEUQnSY11kcEsg2Ng-_X', { action: 'social' }).then(function (token) {
            //console.log(token);


            document.getElementById("hiddenToken").value = token;
            
            const tokenId = document.getElementById("hiddenToken").value;
            const xhr = new XMLHttpRequest();
            //const tokenId = token;
            //const xhr = new XMLHttpRequest();//前端傳給後端的方法
            xhr.open("POST", "Verification.ashx");
            // xhr.setRequestHeader("Content-Type", "application/json");
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); // 要用 x-www-form-urlencoded (類似MIME)方式傳送
         
            //xhr.onload = function () {
            //    console.log('hiddenToken');
            //    const res = this.responseText;
            //    console.log(this.responseText);
            //};
            //xhr.send(`hiddenToken=${tokenId}`);
        });
    });
</script>
