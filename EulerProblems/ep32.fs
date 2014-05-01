module ep32

//http://projecteuler.net/problem=32

//1 digit x 4 digits can gives 5 digits length result
//digits have to be unique
let n1 = seq {2..9}
let n4 = seq {1234..9876}

let products1 = 
    seq {for n in n1 do
            for m in n4 do
                yield (n, m)
    }

//2 digit x 3 digits can gives 5 digits length result
//digits have to be unique
let n2 = seq {12..98}
let n3 = seq {123..987}

let products2 = 
    seq {for n in n2 do
            for m in n3 do
                yield (n, m)
    }

let all = "123456789".ToCharArray() 

// check if n and m pass EP32 needs
let is_pandigital n m =
    let convert n m =
        let r = n.ToString() + m.ToString() + (n*m).ToString()
        r |> string |> fun s -> s.ToCharArray() |> Array.sort
  
    let r = convert n m

    let allEqual =
        Array.forall2 (fun e1 e2 -> e1 = e2)

    if (r.Length = 9 && allEqual all r) 
    then true
    else false

//Set filter out duplicate products      
let convertToSet products = 
    products 
    |> Seq.filter (fun (n, m) -> is_pandigital n m) 
    |> Seq.map (fun (n, m) -> n*m) 
    |> Set.ofSeq

let solve =
    let p1 = convertToSet products1
    let p2 = convertToSet products2

    Set.union p1 p2 
    |> Set.toList 
    |> List.sum
