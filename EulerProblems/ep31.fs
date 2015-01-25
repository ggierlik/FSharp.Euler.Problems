module ep31
//http://projecteuler.net/problem=31

//coin change algorithm based on 
//http://www.algorithmist.com/index.php/Coin_Change
let solve total =
    //let coins = [1; 2; 5; 10; 20; 50; 100; 200]
    let coins = [200; 100; 50; 20; 10; 5; 2; 1]

    let rec count n m =
        //printfn "%d %d" n m
        if n = 0 then 1
        else if n < 0 then 0
        else if m <= 0 && n >= 1 then 0
        else (count n (m-1)) + (count (n - coins.[m-1]) m)

    count total coins.Length

