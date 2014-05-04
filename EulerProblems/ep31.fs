module ep31
//http://projecteuler.net/problem=31

//[<Measure>] type p
//[<Measure>] type P

//returns infinite sequence of n (value of coin)
let getInfSeq n = Seq.unfold (fun i -> Some(i, i)) n

let coins = [1; 2; 5; 10; 20; 50; 100; 200]

let coinsSeq = coins |> List.map (fun i -> getInfSeq i)

let solve total =
    let rec calc acc sum coins =
        printfn "%d %d" acc

        if List.isEmpty coins then acc
        else
            let m = coins |> List.head |> Seq.head

            let new_sum = sum + m
            if new_sum = total then acc+1
            else if new_sum < total then acc + calc acc (sum+m) coins
            else acc + calc acc sum (coins |> List.tail)

    calc 0 0 coinsSeq
