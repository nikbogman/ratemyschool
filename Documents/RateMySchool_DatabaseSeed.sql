DROP DATABASE IF EXISTS ratemyschool;
CREATE DATABASE ratemyschool;
USE ratemyschool;

CREATE TABLE school
(
    id     varchar(36)                              NOT NULL,
    name   nvarchar(100)                            NOT NULL,
    city   nvarchar(50)                             NOT NULL,
    number int                                      NOT NULL,
    type   ENUM ('language', 'stem', 'specialized') NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE language_school
(
    id                 varchar(36)  NOT NULL,
    primary_language   nvarchar(12) NOT NULL,
    secondary_language nvarchar(12) NOT NULL,
    score_requirement  int DEFAULT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (id) REFERENCES school (id) ON DELETE CASCADE
);

CREATE TABLE specialized_school
(
    id             varchar(36)  NOT NULL,
    specialization nvarchar(30) NOT NULL,
    assessment     text DEFAULT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (id) REFERENCES school (id) ON DELETE CASCADE
);

CREATE TABLE stem_school
(
    id                varchar(36)  NOT NULL,
    study             nvarchar(30) NOT NULL,
    score_requirement int     DEFAULT NULL,
    entry_assessment  boolean DEFAULT false,
    PRIMARY KEY (id),
    FOREIGN KEY (id) REFERENCES school (id) ON DELETE CASCADE
);

CREATE TABLE user
(
    id               varchar(36)                    NOT NULL,
    password         nvarchar(60)                   NOT NULL,
    email            nvarchar(30)                   NOT NULL,
    birth_year       int                            NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE review
(
    id         varchar(36) NOT NULL,
    created_at datetime             DEFAULT NOW(),
    content    text        NOT NULL,
    rating     int         NOT NULL,
    reported   boolean              DEFAULT false,
    school_id  varchar(36) NOT NULL,
    user_id    varchar(36) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (school_id) REFERENCES school (id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES user (id) ON DELETE CASCADE
);

CREATE TABLE report
(
    id          varchar(36) NOT NULL,
    reported_at datetime DEFAULT NOW(),
    reason      text        NOT NULL,
    review_id   varchar(36) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (review_id) REFERENCES review (id) ON DELETE CASCADE
);
