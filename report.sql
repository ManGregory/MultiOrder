select DATEPART(MONTH, o.Date), u.Name, count(o.Id)
from Orders o 
	join Users u on u.Id = o.UserId
where
	o.IsSigned = 1
group by 
	DATEPART(MONTH, o.Date), u.Name;