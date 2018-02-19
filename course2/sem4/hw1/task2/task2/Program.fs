let fibonacci n = 
    let rec fibonacciTemp n k first second = 
        if k = n then second else fibonacciTemp n (k+1) second (first + second)
    fibonacciTemp n 1 0 1