#region Instructions JP

/*
### 総合演習：オンラインショップ管理システム

**テーマ**: オンラインショップ管理システム

この演習では、オブジェクト指向プログラミングのすべての概念を活用して、オンラインショップ管理システムを設計します。以下の要素をカバーします：

1. **クラス**: 商品、顧客、注文、ショッピングカートなどのクラスを設計しましょう。
2. **プロパティ**: 商品の名前、価格、顧客の名前、住所など、それぞれのオブジェクトが持つべきプロパティを定義します。
3. **インデクサ**: 商品のリストや顧客の注文履歴など、インデクサを使用してアクセスできるデータを設計します。
4. **演算子のオーバーライド**: 例えば、商品同士の比較や顧客の注文の合計金額を計算するために演算子をオーバーライドします。
5. **継承**: 商品カテゴリや顧客タイプごとに異なる振る舞いを持つクラスを作成するために継承を使用します。
6. **ポリモーフィズム**: 同じメソッド名で異なるクラスに対して異なる動作を実現します。例えば、顧客が注文を確認するメソッドは、通常の顧客とプレミアム顧客で異なるロジックを実装します。
7. **抽象クラス**: 商品の基底クラスや顧客の基底クラスなど、共通の特性を持つクラスを抽象化します。
8. **静的クラス**: ユーティリティメソッドや定数など、インスタンス化せずに利用できるクラスを設計します。
9. **インターフェース**: 支払い方法や配送方法など、複数のクラスで共有される振る舞いを定義するためにインターフェースを使用します。
10. **コンストラクタ**: オブジェクトの初期化を行うためにコンストラクタを定義します。
11. **例外**: 不正な操作やエラー状態に対処するために例外処理を導入します。
12. **デリゲート**: イベント処理や非同期操作など、異なるコンポーネント間でメッセージングを実現するためにデリゲートを使用します。
13. **イベント**: 注文確認や支払い完了などの重要なステップでイベントを発生させる仕組みを設計します。
14. **ジェネリクス**: 汎用的なリストやコレクションを実現するためにジェネリクスを使用します。

### 設計の方針

1. **クラス設計**: 商品、顧客、注文、ショッピングカートなどの各クラスを設計し、それぞれがどのような特性を持つか、どのような振る舞いをするかを明確にします。
2. **関係性の設計**: 商品と顧客、注文と配送、支払いといった、各オブジェクト間の関係性を設計します。
3. **例外処理の設計**: エラーが発生した場合の挙動や、不正な操作を検知し、それに対処する方法を設計します。
4. **ユーザーインターフェースの検討**: コンソールやウェブインターフェースを通じて、ユーザーがシステムをどのように操作するかを検討します。
5. **テスト計画**: 各クラスやメソッドに対するテスト計画を立て、システムが正しく動作することを確認します。

この設計ガイドラインに基づいて、オンラインショップ管理システムの設計と実装を進めてください。
*/

#endregion

#region Instructions EN

/*
### Comprehensive Exercise: Online Store Management System

**Theme:** Online Store Management System

In this exercise, you will design an online store management system using all the concepts of object-oriented programming. Here are the elements you will cover:

1. **Classes**: Design classes such as Product, Customer, Order, Shopping Cart, etc.
2. **Properties**: Define properties such as product name, price, customer name, address, etc., for each object.
3. **Indexer**: Use indexers to access data such as the list of products or a customer's order history.
4. **Operator Overloading**: Override operators to compare products or calculate the total amount of an order.
5. **Inheritance**: Create subclasses like PhysicalProduct and DigitalProduct to manage different types of products.
6. **Polymorphism**: Implement methods like CalculateTotal() that can behave differently based on the product type.
7. **Abstract Class**: Define an abstract class like Product to encapsulate common functionalities.
8. **Static Class**: Utilize a static class for utility methods such as calculating taxes or discounts.
9. **Interface**: Define interfaces like IPaymentMethod to manage different payment methods.
10. **Constructor**: Initialize objects with constructors to ensure a consistent initial state.
11. **Exception Handling**: Add exception handlers to manage errors such as invalid credit card information.
12. **Delegate**: Use delegates for functionalities like notifying order confirmation.
13. **Event**: Trigger events for significant actions like payment confirmation.
14. **Generics**: Use generics for creating generic collections of products or customers.

### Design Guidelines

1. **Class Design**: Define base classes such as Product, Customer, Order, etc., specifying their characteristics and interactions.
2. **Relationships**: Define relationships between objects, such as between Product and Customer, Order and Delivery, Payment and Confirmation.
3. **Exception Management**: Plan responses to potential errors and unexpected situations, emphasizing system reliability.
4. **User Interface**: Consider the user interface, whether it's a console or web interface, to allow users to interact seamlessly with the system.
5. **Testing Plan**: Develop a testing plan for each class and method to ensure the system functions correctly.

By following these design guidelines, you can proceed with designing and implementing a comprehensive online store management system.
*/

#endregion

#region Instructions FR

/*
### Exercice intégral : Système de gestion d'un magasin en ligne

**Thème :** Système de gestion d'un magasin en ligne

Dans cet exercice, vous allez concevoir un système de gestion d'un magasin en ligne en utilisant tous les concepts de la programmation orientée objet. Voici les éléments que vous allez couvrir :

1. **Classes** : Concevoir des classes telles que Produit, Client, Commande, Panier d'achat, etc.
2. **Propriétés** : Définir les propriétés comme nom du produit, prix, nom du client, adresse, etc., pour chaque objet.
3. **Indexeur** : Utiliser des indexeurs pour accéder à des données comme la liste des produits ou l'historique des commandes d'un client.
4. **Override d'opérateurs** : Surcharger les opérateurs pour comparer des produits ou calculer le montant total d'une commande.
5. **Héritage** : Créer des sous-classes comme ProduitPhysique et ProduitNumérique pour gérer différents types de produits.
6. **Polymorphisme** : Implémenter des méthodes comme CalculerMontant() qui peuvent avoir un comportement différent selon le type de produit.
7. **Classe abstraite** : Définir une classe abstraite comme Produit pour regrouper des fonctionnalités communes.
8. **Classe statique** : Utiliser une classe statique pour des méthodes utilitaires comme CalculerTVA().
9. **Interface** : Définir des interfaces comme IMethodePaiement pour gérer différents modes de paiement.
10. **Constructeur** : Initialiser les objets avec des constructeurs pour garantir un état initial cohérent.
11. **Gestion des exceptions** : Ajouter des gestionnaires d'exceptions pour gérer les erreurs comme une carte de crédit invalide.
12. **Delegate** : Utiliser des délégués pour des fonctionnalités telles que la notification de confirmation de commande.
13. **Event** : Déclencher des événements pour des actions importantes comme la confirmation de paiement.
14. **Génériques** : Utiliser des types génériques pour créer des collections génériques de produits ou de clients.

### Directives de conception

1. **Conception de classes** : Définir les classes de base comme Produit, Client, Commande, etc., en spécifiant leurs caractéristiques et leurs interactions.
2. **Relations** : Définir les relations entre les objets, par exemple entre Produit et Client, Commande et Livraison, Paiement et Confirmation.
3. **Gestion des exceptions** : Prévoir les réponses aux erreurs potentielles et aux situations inattendues, en mettant l'accent sur la fiabilité du système.
4. **Interface utilisateur** : Considérer l'interface utilisateur, qu'il s'agisse d'une interface console ou web, pour permettre aux utilisateurs d'interagir facilement avec le système.
5. **Plan de test** : Développer un plan de test pour chaque classe et méthode afin de garantir le bon fonctionnement du système.

En suivant ces directives de conception, vous pourrez avancer dans la conception et l'implémentation d'un système de gestion d'un magasin en ligne complet.
*/

#endregion

#region Planning

//Class:
//    Product (productId, name, price)
//        Clothes (colors[], category)
//        Cosmetics (colors[], allergies[])
//        Food (allergies[])
//    ProductManager (products[])
//    Customer (customerId, firstname, lastname, address)
//    CustomerManager (customers[])
//    Order (orderId, orderedproducts[], totalOrderPrice, FK_delivery, FK_payment, FK_customerId)
//    ShoppingCart (cartProducts, totalCartPrice)
//    Delivery (deliveryId, deliveryCompany, deliveryDate)
//    Payment (isPaid)
//        PaymentType[enum]
//        IPaypal (username, pass)
//        ICard (name, cardNumber, securityNumber, pin)

//Indexer:
//    products(ProductManager), customers(CustomerManager)

//Override of Operators
//    double + product = sum(product.price)

//Polymorphism
//    products[] (ProductManager)

//Abstract

//Static

//Interface

//Exception

//Delegate

//Event
//    isPaid (Payment)? => message + new order

//Generic

#endregion