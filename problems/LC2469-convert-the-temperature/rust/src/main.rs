fn main() {
    let result = Solution::convert_temperature(122.11);
    println!("{:?}", result);
}

struct Solution;

impl Solution {
    pub fn convert_temperature(celsius: f64) -> Vec<f64> {
        let kelvin = celsius + 273.15;
        let fahrenheit = celsius * 1.8 + 32f64;

        return vec![kelvin, fahrenheit];
    }
}
