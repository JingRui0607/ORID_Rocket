 
 DECLARE @today int
 select @today = DATEPART(weekday,@date)
  
select 週一目標 as target
from ORID_data 

where Sid= @name and 填寫時間 between 
DATEADD(day,      -((  select
case when @today=1 then 8 
when @today=2 then 2
when @today=3 then 3
when @today=4 then 4
when @today=5 then 5
when @today=6 then 6
when @today=7 then 7
end  
) -2)  ,@date) 
and DATEADD(day,-((   
select case when @today=1 then 8 
when @today=2 then 2
when @today=3 then 3
when @today=4 then 4
when @today=5 then 5
when @today=6 then 6
when @today=7 then 7
end  )-3 ),@date)
 