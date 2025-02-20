import Card, {CardBody} from "./components/Card";
import List from "./components/List";


function App(){
  const list = ["An item", "A second ", "A third ", "A fourth ", "And a fifth one"];
  return <Card>
    <CardBody title="titulooo" text="texto">
    </CardBody>
    <List data={list}/>

  </Card>;
}
export default App;