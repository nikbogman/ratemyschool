CREATE TABLE `school` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `name` nvarchar(255) NOT NULL,
  `city` nvarchar(255) NOT NULL,
  `number` int NOT NULL,
  `rating` float DEFAULT 0
);

CREATE TABLE `language_school` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `primary_language` nvarchar(12) NOT NULL,
  `secondary_language` nvarchar(12) NOT NULL,
  `score_requirement` int DEFAULT null
);

CREATE TABLE `specialized_school` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `specialization` nvarchar(30) NOT NULL,
  `assessment` text DEFAULT null
);

CREATE TABLE `stem_school` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `study` nvarchar(30) NOT NULL,
  `score_requirement` int DEFAULT null,
  `entry_assessment` boolean DEFAULT false
);

CREATE TABLE `review` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `content` text NOT NULL,
  `created_at` datetime DEFAULT (NOW()),
  `rating` float,
  `school_id` int NOT NULL,
  `reported` boolean DEFAULT false,
  `user_id` int NOT NULL
);

CREATE TABLE `report` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `reason` text NOT NULL,
  `reported_at` datetime DEFAULT (NOW()),
  `review_id` int NOT NULL
);

CREATE TABLE `user` (
  `id` varchar(36) PRIMARY KEY NOT NULL,
  `username` nvarchar(25) NOT NULL,
  `salt` nvarchar NOT NULL,
  `hash` nvarchar NOT NULL,
  `email` nvarchar NOT NULL,
  `birthyear` int NOT NULL
);

ALTER TABLE `language_school` ADD FOREIGN KEY (`id`) REFERENCES `school` (`id`);

ALTER TABLE `specialized_school` ADD FOREIGN KEY (`id`) REFERENCES `school` (`id`);

ALTER TABLE `stem_school` ADD FOREIGN KEY (`id`) REFERENCES `school` (`id`);

ALTER TABLE `review` ADD FOREIGN KEY (`school_id`) REFERENCES `school` (`id`);

ALTER TABLE `report` ADD FOREIGN KEY (`review_id`) REFERENCES `review` (`id`);

ALTER TABLE `review` ADD FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);
