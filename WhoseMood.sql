select CONVERT(varchar(10), 填寫時間, 111)as date1 ,

case when 心情='非常開心'then'5' when 心情='開心'then'4' when 心情='普通'then'3' when 心情='不開心'then'2' when 心情='非常不開心'then'1' 
when 心情='5'then'5' when 心情='4'then'4' when 心情='3'then'3' when 心情='2'then'2' when 心情='1'then'1'
end as mood  
from ORID_data  
where Sid=@name