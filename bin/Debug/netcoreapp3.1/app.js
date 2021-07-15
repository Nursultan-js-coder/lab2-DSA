let d = {};
d["Osh"] = 290000;
d["Bishkek"] = 1500000;
let values = Object.values(d);
console.log(values);
values.forEach((num) => {
  console.log("num:" + num);
});
