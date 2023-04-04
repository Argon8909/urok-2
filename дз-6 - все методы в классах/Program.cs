using System.Text;
using дз_4_4;

ArrCalk Calk = new ArrCalk();

int[] Arr = Array.ConvertAll(Calk.Input("Введите элементы массива через пробел: ").Split(' '), int.Parse);

Calk.OutputResult(Arr);
