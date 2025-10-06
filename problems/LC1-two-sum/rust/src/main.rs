use std::collections::HashMap;
use std::{panic, vec};

struct Solution;

fn main() {
    println!("Hello, world!");

    let nums = vec![2, 7, 11, 15];
    let res = Solution::two_sum(nums, 26);
    println!("{:?}", res);
}

// Naive [O(n^2), O(1)]
impl Solution {
    pub fn naive_two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        for i in 0..nums.len() - 1 {
            for j in i + 1..nums.len() {
                if nums[i] + nums[j] == target {
                    return vec![i as i32, j as i32];
                }
            }
        }

        panic!();
    }
}

// Good [O(n), O(n)]
impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut map: HashMap<i32, i32> = HashMap::new();

        for i in 0..nums.len() {
            let val = nums[i];

            if let Some(prev_key) = map.get(&val) {
                return vec![*prev_key, i as i32];
            } else {
                let diff = target - nums[i];
                map.insert(diff, i as i32);
            }
        }

        panic!();
    }
}
