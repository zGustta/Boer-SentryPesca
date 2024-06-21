create table cidade(
	idcidade serial primary key,
	nomecidade varchar (35)
);

create table cliente(
	cpfcliente bigint unique primary key,
	nomecliente varchar(50) not null,
	rgcliente varchar(13),
	nascimentocliente timestamp not null,
	enderecocliente text not null,
	telefonecliente varchar(14) not null,
	idcidade int not null,
	
	constraint fk_cliente_cidade foreign key (idcidade) references cidade (idcidade)
);

create table fornecedor (
	cnpjfornecedor bigint unique primary key,
	nomefornecedor varchar (50) not null, 
	ederecofornecedor text not null,
	telefonefornecedor varchar(14) not null,
	emailfornecedor varchar(60) not null,
	idcidade int not null,
	
	constraint fk_fornecedor_cidade foreign key (idcidade) references cidade (idcidade)	
);

create table categoria (
	idcategoria serial primary key,
	nomecategoria varchar(30) not null
);

create table tipoproduto (
	idtipoproduto serial primary key,
	nometipoproduto varchar(30) not null
);

create table produto (
	barrasproduto bigint unique primary key,
	nomeproduto varchar(35) not null,
	validadeproduto timestamp,
	custoproduto money not null,
	precoproduto money not null,
	quantidadeproduto int,
	idcategoria int not null,
	idtipoproduto int not null,
	
	constraint fk_produto_categoria foreign key (idcategoria) references categoria (idcategoria),
	constraint fk_produto_tipoproduto foreign key (idtipoproduto) references tipoproduto (idtipoproduto)
	
);

create table venda (
	idvenda serial primary key,
	datavenda timestamp not null,
	totalvenda money,
	cpfcliente bigint,
	
	constraint fk_venda_cliente foreign key (cpfcliente) references cliente (cpfcliente)
);

create table itensvenda (
	idvenda int not null,
	barrasproduto bigint not null,
	quantidadeitensvenda int not null, 
	valoritensvenda money not null,
	
	constraint pk_itensvenda primary key (idvenda,barrasproduto),
	constraint fk_itensvenda_venda foreign key (idvenda) references venda (idvenda),
	constraint fk_itensvenda_produto foreign key (barrasproduto) references produto (barrasproduto)
	
);

