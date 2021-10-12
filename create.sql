CREATE TABLE IF NOT EXISTS  users (
    id                          bigserial NOT NULL,
    status                      varchar(50) NOT NULL,
    fullname                    varchar(80) NOT NULL,
    doc_id                      varchar(20) NOT NULL,
    enabled                     smallint NOT NULL,
    birth_date                  datetime year to second,
    PRIMARY KEY (id) CONSTRAINT pk_users
);