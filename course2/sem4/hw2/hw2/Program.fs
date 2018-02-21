(*2.1*)

let f n = 
    let rec count n acc = 
        if n = 0 then acc
        else acc * count (n / 10) (n % 10)
    count n 1