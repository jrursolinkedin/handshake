/*
This method activates the "SwitchPage" method when
one of the navigation tabs are clicked.
*/
window.onload = () => {
    const tab_switchers = document.querySelectorAll('[data-switcher]');
    // Traverses the tabs.
    for (let i = 0; i < tab_switchers.length; i++) {
        const tab_switcher = tab_switchers[i];
        const page_id = tab_switcher.dataset.tab;
        // Waits until the event happens...
        tab_switcher.addEventListener('click', () => {
            document.querySelector('.tabs .tab.is-active').classList.remove('is-active');
            tab_switcher.parentNode.classList.add('is-active');
            SwitchPage(page_id);
        });
    }
}

/*
This method actually performs the swtiching
between the pages.
*/
function SwitchPage (page_id) {
    // Removes page and adds a new one.
    console.log(page_id);
    const current_page = document.querySelector('.pages .page.is-active');
    current_page.classList.remove('is-active');
    const next_page = document.querySelector(`.pages .page[data-page="${page_id}"]`);
    next_page.classList.add('is-active');
}

/*
This method reads a given text file and 
returns all the contents in a string.
*/
function readTextFile(file){
    var allText;
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function (){
        if(rawFile.readyState === 4){
            if(rawFile.status === 200 || rawFile.status == 0)
            {
                allText = rawFile.responseText;
                console.log(allText.charAt(0))
                //alert(allText);
            }
        }
    }
    rawFile.send(null);
    return allText; 
}

/*
This method calculates all the above the values
that were printed out in the function above. Lastly,
it returns the posterior probabilities for 'true' and
'false' in an 2-item array [false,true].
*/
function NaiveBayes(inp){
    // Counters for "true" and "false"
    // for target attribute.
    var c1_count = 0;
    var c2_count = 0;
    // Counts for selected attributes.
    var c1 = [0, 0, 0, 0, 0];
    var c2 = [0, 0, 0, 0, 0];
    // Same as above but divided by number
    // of lines (rows in dataset).
    var pc1 = [0, 0, 0, 0, 0];
    var pc2 = [0, 0, 0, 0, 0];
    // Gets all the data from the dataset.
    var rows = 1999;
    var cols = 6;
    var data = [];
    var f = readTextFile("Final_COVID_Dataset.txt");
    var lines = f.split("|");
    console.log(lines);
    for(var r = 0; r < rows; r++){
        for(var c = 0; c < cols; c++){
            data.push(lines[r].split(",")[c]);
        }
    }
    // Holds number of attributes.
    var attrs = cols;
    // Gets the counts for "c1_count"
    // and "c2_count".
    for(var i = 0; i <= (data.length-6); i+=6){
        if(data[(i+5)].toString().toLowerCase() === "true"){
            c1_count++;
        }
        if(data[(i+5)].toString().toLowerCase() === "false"){
            c2_count++;
        }
    }
    // Gets probability for "true" and "false"
    // values in the target column. Or, it gives
    // Prior Probability, P(A).
    var pofc1 = c1_count/parseFloat(lines.length);
    var pofc2 = c2_count/parseFloat(lines.length);
    // User user for selected attributes.
    var inpdata = inp.split(",");
    // Counts the number of times the selected
    // attribute shows up.
    for(var i = 0; i < data.length; i+=6){
        for(var j = 0; j < (attrs - 1); j++){
            if(data[(i + j)].toString() === inpdata[j].toString()){
                if(data[(i + (attrs-1))].toString().toLowerCase() === "true"){
                    c1[j]++;
                }
                else{
                    c2[j]++;
                }
            }
        }
    }
    // This gives you the "Normalizing factor", P(C).
    var normal = parseFloat(1);
    for(var y = 0; y < c1.length; y++){
        normal *= parseFloat((c1[y]+c2[y])/parseFloat(data.length/cols));
    }
    // This gives "Likelyhood", P(C|A).
    for(var x = 0; x < c1.length; x++){
        pc1[x] = c1[x]/parseFloat(c1_count);
        pc2[x] = c2[x]/parseFloat(c2_count);
    }
    var pxbyc1 = 1;
    var pxbyc2 = 1;
    for(var x = 0; x < pc1.length; x++){
        pxbyc1 *= pc1[x];
        pxbyc2 *= pc2[x];
    }
    // This gives P(C|A)*P(A).
    pxbyc1 *= pofc1;
    pxbyc2 *= pofc2;
    // This gives you posterior probability,
    // P(A|C) = (P(C|A)*P(A))/P(c)
    var pprob1 = pxbyc1/parseFloat(normal);
    var pprob2 = pxbyc2/parseFloat(normal);
    // Finally, return [false %,true %].
    return [pprob2, pprob1];
}

/*
This method gets all the user inputs and finds
the bayesian probability for testing positve
and negative for COVID-19.
*/
 function Main(){
     // Get values from user.
     var cFever = parseFloat(document.getElementById('n1').value);
     var pain = (document.getElementById('n2').value).toString().toLowerCase().trim();
     var cAge = parseInt(document.getElementById('n3').value);
     var nose = (document.getElementById('n4').value).toString().toLowerCase().trim();
     var breathing = (document.getElementById('n5').value).toString().toLowerCase().trim();
     // Convert "cFever" and "cAge" to noncontinues attributes.
     var fever = "";
     var age = "";
     switch(true){
         case (cFever < 99):
            fever = "normal";
            break;
         case (cFever < 100):
            fever = "low";
            break;
         case (cFever < 102):
            fever = "moderate";
            break;
         case (cFever < 105):
            fever = "high";
            break;
         default:
            fever = "high";
            break; 
     }
     switch(true){
         case (cAge < 20):
             age = "teens";
             break;
         case (cAge < 30):
             age = "twenties";
             break;
         case (cAge < 40):
             age = "thirties";
             break;
         case (cAge < 50):
             age = "forties";
             break;
         case (cAge < 60):
             age = "fifties";
             break;
         case (cAge < 70):
             age = "sixties";
             break;
         case (cAge < 80):
             age = "seventies";
             break;
         case (cAge < 90):
             age = "eighties";
             break;
         default:
             age = "eighties";
             break;
     }     
     // Perform Naive Bayes.
     var probabilities = NaiveBayes(fever+","+pain+","+age+","+nose+","+breathing);
     // Ouput the probabilities for testing positive
     // and negative.
     document.getElementById('result1').value = (Math.round(probabilities[1]*10000)/100).toString();
     document.getElementById('result2').value = (Math.round(probabilities[0]*10000)/100).toString(); 
 }
