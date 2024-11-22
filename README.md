# AppHerois

Criação das tabelas do banco de dados via script utilizando Postgresql:

create table herois (
	id serial PRIMARY KEY,
	nome varchar(120) not null,
	nomeheroi varchar(120) not null,
	datanascimento date,
	altura float not null,
	peso float not null
);

create table super_poderes(
	id serial PRIMARY KEY,
	superpoder varchar(50) not null,
	descricao varchar(250)
);

create table herois_superpoderes(
	heroiid int not null,
	superpoderid int not null
);

alter table herois_superpoderes
    add constraint fk1_herois_superpoderes
    foreign key (HeroiId) 
    REFERENCES herois (Id);
    
alter table herois_superpoderes
    add constraint fk2_herois_superpoderes
    foreign key (SuperpoderId) 
    REFERENCES super_poderes (Id);

ALTER TABLE herois ADD CONSTRAINT uk_herois UNIQUE (nomeheroi);
    
   select * from herois;
   select * from super_poderes;
   select * from herois_superpoderes;
