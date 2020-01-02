#### 背景

* 模拟一个**卖商品**的 API

#### 相关 .cs 介绍

* StudySoldController.cs
* TransactionService.cs
* SellGoodsTransactionService.cs
* ISellGoodsInterface.cs
* SellGoods.cs

#### Controller

* 你可以复制 **StudySoldController.cs** 并修改它
* Swagger 能依照 **StudySoldController.cs** 的注释生成 API 文档

#### Application Service Classes

* **TransactionService.cs** 是一个基类，能否创建 transcation 的 context
* **SellGoodsTransactionService.cs** 继承 **TransactionService.cs** 并调用具体的业务方法

#### Business Interface and Concrete Class

* **ISellGoodsInterface.cs** 具体业务的接口
* **SellGoods.cs** 实现 **ISellGoodsInterface.cs**
