create trigger tr_DeleteVillain
on Villains
instead of delete
as begin

delete from MinionsVillains
where VillainId in(
	select Id
	from deleted
)

delete from Villains
where Id in(
	select Id
	from deleted
)

end