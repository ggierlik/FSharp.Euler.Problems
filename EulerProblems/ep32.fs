module ep32

//http://projecteuler.net/problem=32

// n * m = p

let ns = seq {1..98}

let ms n = Seq.unfold (fun i -> Some (i, i+1)) (n)

let is_pandigital n m =
    let all = "123456789".ToCharArray() |> Set.ofArray

    let makeSet n =
        n |> string |> fun s -> s.ToCharArray() |> Array.toList |> Set.ofList

    let sn = makeSet n
    let sm = makeSet m
    let sp = makeSet (n*m)

    let seqOfSets = [sn; sm; sp] |> List.toSeq
    
//    Set.intersect
//    Set.intersectMany

    //seqOfSets
    let r1 = Set.unionMany seqOfSets

    let diff = Set.intersect all r1
    let union = Set.union all r1

    true




