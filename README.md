# PokerCombinations

Чтобы сконфигурировать вашу начальную руку, запрещенные карты и предикат, по которому считать кол-во комбинаций отредактируйте файл **Program.cs**, а именно конструктор *CoreAssembly*.

Чтобы добавить предикат, по которому будут считаться комбинации, добавьте строку 

```c#
assembly.BruteForcer.SetHandCheckRule(predicate);
```
где predicate - 
```c#
Func<IEnumerable<Combination>,bool>
```

Например:
```c#
assembly.BruteForcer.SetHandCheckRule(hand => 
	hand.Contains(Combination.TwoOfKind) &&       
	hand.Contains(Combination.Flush) && 
	!hand.Contains(Combination.ThreeOfKind)&&
	!hand.Contains(Combination.RoyalFlush));
```
Проверяем, что получился и Flush, и 2+2, но не получилось 3к и RoyalFlush.

Чтобы задать комбинации, которые участвуют в игре, нужно в классе *CoreAssembly* найти метод *AddRules* и оставить только те комбинации, которые Вам нужны.

Пример:

```c#
private void AddRules()  
{  
    //CombinationChecker.AddCombinationRule(Combination.TwoPairs, CombinationRulesProvider.GetTwoPairsRule());  
  CombinationChecker.AddCombinationRule(Combination.Flush, CombinationRulesProvider.GetFlushRule());  
    CombinationChecker.AddCombinationRule(Combination.None, el=> true);  
    //CombinationChecker.AddCombinationRule(Combination.Straight, CombinationRulesProvider.GetStraightRule());  
 //CombinationChecker.AddCombinationRule(Combination.StraightFlush, CombinationRulesProvider.GetStraightFlushRule());  
 CombinationChecker.AddCombinationRule(Combination.FourOfKind, CombinationRulesProvider.GetFourOfKindRule());  
    //CombinationChecker.AddCombinationRule(Combination.ThreeOfKind, CombinationRulesProvider.GetThreeOfKindRule());  
  CombinationChecker.AddCombinationRule(Combination.TwoOfKind, CombinationRulesProvider.GetTwoOfKindRule());  
    //CombinationChecker.AddCombinationRule(Combination.ThreePlusTwoOfKind, CombinationRulesProvider.GetThreePlusTwoOfKindRule());  
  CombinationChecker.AddCombinationRule(Combination.RoyalFlush, CombinationRulesProvider.GetRoyalFlushRule());  
}
```
Тут оставляем только RoyalFlush, 2k, 4k, Flush и None(то есть ни одной комбинации не получилось).

Когда-нибудь я сделаю консольный интерфейс)
