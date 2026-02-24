# QuickerSFV
Multithread, command-line Hash verify tool compatible with sfv format

## Why QuickerSFV?
I own a 24-core i9 laptop and I prefer running without turbo to save power. It still provides excellent multicore performance but poor singlecore performance, which makes nearly all SFV/MD5 verify tool running slow.  
One core fighting with 23 cores idle really sucks, so I made this.  
QuickerSFV will use all your cores to generate hash in batch. To be even faster, it automatically adjust sequence to calculate largest file first. (In future there may even be additional algorithm to balance tasks based on core numbers for even better multicore utilization.)  
