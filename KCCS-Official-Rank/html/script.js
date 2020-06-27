function createNewRank(members) {
    var table = document.getElementsByClassName("Members")[0];
    var tbody = document.createElement("tbody");
    var tr = document.createElement("tr");
    var td1 = document.createElement("td");
    td1.appendChild(document.createTextNode(members['name']));
		var img = document.createElement("img");
		img.src = members['avatar'];
		img.className = "icon"
		td1.appendChild(img);
		var td2 = document.createElement("td");
    td2.appendChild(document.createTextNode(members['exp']));
		var td3 = document.createElement("td");
    td3.appendChild(document.createTextNode(members['lvl']));
		var td4 = document.createElement("td");
    td4.appendChild(document.createTextNode(members['needExp']));
    tr.appendChild(td1);
		tr.appendChild(td2);
		tr.appendChild(td3);
		tr.appendChild(td4);
		tr.className = "rank";
    tbody.appendChild(tr);
		table.appendChild(tbody);
}
fetch("https://kccs-official-rank--stupidbenz.repl.co/user.json")
	.then(function (resp) {
		return resp.json();
	})
	.then(function (data) {
		var membersdata = [];
		var membersname = [];
		let i = 0;
		let j = 0;
		for(prop in data) {
			membersdata[j] = data[prop];
			membersname[i] = prop;
			i++;
			j++;
		}
		membersdata.sort(function(a, b) {
			return b.exp - a.exp;
		})
		for(i = 0; i < membersname.length; i++){
			createNewRank(membersdata[i]);
		}
	}).catch(err => {
        console.error(err.stack);
    });

function toggle(){
  var sec = document.getElementById('sec');
  var nav = document.getElementById('navigation');
  sec.classList.toggle('active');
  nav.classList.toggle('active');
}