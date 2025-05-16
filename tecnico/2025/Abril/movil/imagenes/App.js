import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Image, ScrollView } from 'react-native';
import img1 from './assets/Image/img1.jpg'

export default function App() {
  return (
    <ScrollView>
      <View style={styles.container}>
        <Text>Holaaa</Text>
        <Image 
          fadeDuration={1000}
          style={styles.image}
          source={{uri: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT86S_ZlKylXOd3eTqAW5KXxkngeiP-uUxtNA&s'}}
        ></Image>
        <Image 
          fadeDuration={3000}
        
        style={styles.image}
          source={img1}
        ></Image>
        <StatusBar style="auto" />
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  image: {
    width: 200,
    height: 200,
    margin: 15,
    border: '8px solid #663612',
    borderRadius: 15,
    boxShadow: '10px 10px 15px #663612'
  }
});
