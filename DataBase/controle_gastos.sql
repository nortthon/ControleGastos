CREATE DATABASE controle_gastos;
USE controle_gastos;

CREATE TABLE tb_usuario(
	usu_id BIGINT IDENTITY(1,1) PRIMARY KEY,
	usu_nome VARCHAR(50) NOT NULL,
	usu_email VARCHAR(60) UNIQUE NOT NULL,
	usu_login VARCHAR(30) UNIQUE NOT NULL,
	usu_senha VARCHAR(255) NOT NULL,
	usu_status TINYINT DEFAULT(0) NOT NULL
);

CREATE TABLE tb_tipo(
	tip_id BIGINT IDENTITY(1,1) PRIMARY KEY,
	tip_nome VARCHAR(30) NOT NULL
);

INSERT INTO tb_tipo (tip_nome) VALUES ('Crédito'),('Débito'),('Transferência');

CREATE TABLE tb_categoria(
	cat_id BIGINT IDENTITY(1,1) PRIMARY KEY,
	cat_nome VARCHAR(50) NOT NULL,
	fk_usu_id BIGINT NOT NULL REFERENCES tb_usuario(usu_id)
);

CREATE TABLE tb_conta(
	cont_id BIGINT IDENTITY(1,1) PRIMARY KEY,
	cont_nome VARCHAR(50) NOT NULL,
	cont_saldo DECIMAL(10,2) NOT NULL,
	cont_descricao TEXT NULL,
	fk_usu_id BIGINT NOT NULL REFERENCES tb_usuario(usu_id)
);

CREATE TABLE tb_transacao(
	trans_id BIGINT IDENTITY(1,1) PRIMARY KEY,
	trans_dia INT NOT NULL,
	trans_mes INT NOT NULL,
	trans_ano INT NOT NULL,
	trans_valor DECIMAL(10,2) NOT NULL,
	trans_descricao TEXT,
	fk_tip_id BIGINT NOT NULL REFERENCES tb_tipo(tip_id),
	fk_cont_id BIGINT NOT NULL REFERENCES tb_conta(cont_id),
	fk_cat_id BIGINT NOT NULL REFERENCES tb_categoria(cat_id)
);