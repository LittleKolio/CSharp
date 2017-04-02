select v.Name as VillainName, count(*) as Minions
from Villains as v
join MinionsVillains as mv
	on mv.VillainId = v.Id
	and v.Id = @VillainId
join Minions as m
	on m.Id = mv.MinionId
group by v.Name