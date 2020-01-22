

declare @Startday date

select top(1) @Startday =  startDate from  Student where  (id = @Sid) 


declare @Endday date
select top(1) @Endday = endDate from Student where  (id = @Sid) 

declare @totalWeek int
select   @totalWeek = DATEDIFF(WEEK,@Startday,@Endday)+1;



SELECT    Student.name,  ORID_data.週一目標 AS target , DATEDIFF(WEEK,@Startday,填寫時間)+1 as week

into #week2
FROM            ORID_data INNER JOIN
                         Student ON ORID_data.Sid = Student.id
					 

where (ORID_data.Sid = @Sid) and DATEPART(weekday , 填寫時間)=2





SELECT    #week2.week as week ,isnull(#week2.target,0) as target
into #final
FROM     #week2 RIGHT OUTER JOIN
              week ON #week2.week = week.week


			  where week.week <=@totalWeek

 

select target from  #final where week=@week




