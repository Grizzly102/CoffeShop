-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: coffeshop
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `Id_category` int NOT NULL,
  `Category_product` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Кофе'),(2,'Другие напитки'),(3,'Десерты');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `Order_number` int NOT NULL AUTO_INCREMENT,
  `Order_list` varchar(45) DEFAULT NULL,
  `User_name` varchar(45) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `Id_barista` int DEFAULT NULL,
  `Order_date` date DEFAULT NULL,
  `Order_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Order_number`),
  KEY `barista_idx` (`Id_barista`),
  CONSTRAINT `barista` FOREIGN KEY (`Id_barista`) REFERENCES `user` (`Id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'21','Иван','ул.Пушкина 29',NULL,'2024-05-19','Получен'),(2,'21','Иван.Е.В','ул.Пушкина 29',NULL,'2024-05-19','Получен'),(5,'321','Артур','ул.Пушкина 29',NULL,'2024-05-20','Получен'),(6,'321','Егор','ул.Пушкина 29',NULL,'2024-05-21','Получен'),(7,'1','A30755','mrohzn100@gmail.com',NULL,'2024-06-03','Получен'),(9,'21','Гость8208','вфы',NULL,'2024-06-03','Получен'),(10,'21','Гость7571','dsa',NULL,'2024-06-03','Получен'),(11,'33','Гость8894','sss',NULL,'2024-06-03','Получен'),(12,'22','Гость7308','fds',NULL,'2024-06-03','Получен'),(13,'22','Гость3840','',NULL,'2024-06-03','Получен'),(14,'11','Иван.Е.В','',NULL,'2024-06-03','Получен'),(15,'11','Гость5580','',NULL,'2024-06-03','Получен'),(16,'1','Гость8886','',NULL,'2024-06-03','Получен'),(17,'1','Гость7270','',NULL,'2024-06-03','Получен'),(18,'1','Гость7103','',NULL,'2024-06-03','Получен'),(19,'1','Иван.Е.В','',NULL,'2024-06-03','В работе'),(20,'22','Гость3456','',NULL,'2024-06-03','Получен'),(21,'11','Гость6076','mrohzn100@gmail.com',NULL,'2024-06-03','Оформлен'),(22,'1','Гость1956','',NULL,'2024-06-03','Оформлен'),(23,'221','Гость21512','',NULL,'2024-06-03','Оформлен'),(24,'211','Гость94888','',NULL,'2024-06-03','Оформлен'),(25,'322','Гость93150','mrohzn100@gmail.com',NULL,'2024-06-03','Готов'),(26,'21','Гость13758','',NULL,'2024-06-03','Оформлен'),(27,'321','Гость98165','',NULL,'2024-06-03','Оформлен'),(28,'811','Гость24866','mrohzn100@gmail.com',NULL,'2024-06-04','Получен'),(29,'21','Гость26126','Mrohzn100@gmail.com',NULL,'2024-06-11','Оформлен'),(30,'32','Гость93055','mrohzn100@gmail.com',NULL,'2024-06-11','Оформлен');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `Article` int NOT NULL,
  `Id_category` int DEFAULT NULL,
  `Product_name` varchar(20) DEFAULT NULL,
  `Cost` int DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Photo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Article`),
  KEY `category_idx` (`Id_category`),
  CONSTRAINT `category` FOREIGN KEY (`Id_category`) REFERENCES `category` (`Id_category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,1,'Американо',69,'','/Image/americano.jpg'),(2,1,'Капучино',89,NULL,'/Image/cappuccino.jpg'),(3,1,'Эспрессо',59,NULL,'/Image/espesso.jpg'),(4,1,'Латте',99,NULL,'/Image/latte.jpg'),(5,2,'Черный чай',59,NULL,'/Image/blacktea.jpg'),(6,2,'Зеленый чай',59,NULL,'/Image/greentea.jpg'),(7,3,'Шоколадный пончик',109,NULL,'/Image/chocolatedonut.jpg'),(8,3,'Клубничный пончик',109,NULL,'/Image/raspberrydonut.jpg'),(10,3,'Маффин',159,NULL,'/Image/CoffeLogo.png');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `Id_role` int NOT NULL,
  `Role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_role`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Администратор'),(2,'Бариста'),(3,'Клиент');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size` (
  `Id_size` int NOT NULL,
  `Name_size` varchar(45) DEFAULT NULL,
  `Size_drink` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`Id_size`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES (1,'Маленький','S'),(2,'Средний','M'),(3,'Большой','L');
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id_user` int NOT NULL,
  `Id_role` int DEFAULT NULL,
  `Full_name` varchar(45) DEFAULT NULL,
  `Login` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id_user`),
  KEY `role_idx` (`Id_role`),
  CONSTRAINT `role` FOREIGN KEY (`Id_role`) REFERENCES `role` (`Id_role`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,1,'Егор Андреев','admin','admin',NULL),(2,3,'Иван.Е.В','test','test',NULL),(3,3,'Артур','art','ur',NULL),(4,3,'Егор','eg','or',NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-01 16:51:15
