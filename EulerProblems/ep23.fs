module ep23

//http://projecteuler.net/problem=23
//Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

//http://en.wikipedia.org/wiki/Abundant_number
//Wiki: Every integer greater than 20161 can be written as the sum of two abundant numbers.[4]

let divisors n =
    seq { for i in 1..n/2 do if n % i = 0 then yield i}
            
let d n =
    divisors n |> Seq.sum

let numbers = [0..1000]

let abundants = 
    numbers 
    |> List.map (fun n -> (n, d n))
    |> List.filter (fun (n, d) -> n < d)
    |> List.map (fun (n, d) -> n)

