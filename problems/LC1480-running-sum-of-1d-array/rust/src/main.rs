fn main() {
    let nums = vec![1, 2, 3, 4];

    let res = Solution::running_sum(nums);
    println!("{:?}", res);
}

struct Solution;

// [O(n), O(n)]
impl Solution {
    pub fn running_sum(nums: Vec<i32>) -> Vec<i32> {
        let mut result = Vec::new();
        result.insert(0, nums[0]);

        for i in 1..nums.len() {
            result.insert(i, result[i - 1] + nums[i]);
        }

        return result;
    }
}
