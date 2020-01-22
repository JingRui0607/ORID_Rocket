SELECT    
Student.id,Student.class,Student.image,
CONVERT(varchar(10), 填寫時間, 111)as date1,

case

when  DATEPART(hour, 填寫時間)>=12 then STUFF(Convert(varchar(8),填寫時間,108),1,0,'下午 ') 

when DATEPART(hour, 填寫時間)<12 then STUFF(Convert(varchar(8),填寫時間,108),1,0,'上午 ') 

end as date2 ,

replace(目標完成度,'%','') as reach, 

case when 心情='非常開心'then'5' when 心情='開心'then'4' when 心情='普通'then'3' when 心情='不開心'then'2' when 心情='非常不開心'then'1' 
when 心情='5'then'5' when 心情='4'then'4' when 心情='3'then'3' when 心情='2'then'2' when 心情='1'then'1' end as mood, 

Student.name, 週一目標 as target,  學習歷程描述 as process, 高峰低峰 as sentiment, 每日獲得 as comprehension, 明日行動 as strive, 週五填寫 as Friday 

FROM    ORID_data INNER JOIN
                         Student ON ORID_data.Sid = Student.id 

WHERE (填寫時間 >= (SELECT   CONVERT(datetime, MAX(CONVERT(varchar(10), 填寫時間, 111))) AS 最近的日期 FROM      ORID_data))