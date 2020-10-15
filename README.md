# HashFunction
Blockchain Technologies course independent work no. 1

### hashFunc pseudocode:

```pseudocode
//gets input string thorugh console or through files 

if file = true

then do:

​	for (int i = 0; i < args.Length; i++) {
​		inputString = System.IO.File.ReadAllText(args[i]);
​    	Console.WriteLine("Your input string from file no. {0}:\n {1}", i, inputString);

​	}

end.

else do:

​	inputString = Console.ReadLine(); 

end.

hashFunc(input string); // hash function is called

hashFunc:

bool[] ba = Encoding.ASCII.GetBytes(inputString); // gets ASCII byte array

if ba.Length > 64 

then bool isLong = true;

foreach var ch in ba {

​	if iteration no. %3 or %5 

​	then value= value/ 2;

​	else if iteration no. %7

​	then value = value / 3;

​	else value = value + previousValue;



if not1stLoop = true

then addToFirstValuesAgain();



previousValue = value;

}



convertToHex();

removeHexDashes();



if hexString = short

then do:

​	for i = 0, k=0; i < 64; i++ {

​	finalHashString[i] = hexString[k];

​	k++;

​	if k >= hesString.Length - 1 

​	then do:

​		k = i / 2 - (i / 3);

​		if (k >= hexString.Length) { k = hexString.Length - k; }

​	end.

  end.

else if  hexString = long:

​	while (end not reached) {

​	finalHashString[k] = hexString[i];

​	}

​	if not1stLoop = true 

​	then do:

​		finalHashString[k] += hexString[i];

​	end.

end.
```





### Ataskaita

- *konstitucija.txt* failo skaitymas:

Dėl ne itin tikslaus laiko skaičiavimo, skaičiavau ne tik hashavimo, bet ir nuskaitymo laiką. Bendras vidutinis laikas yra **315ms** .



