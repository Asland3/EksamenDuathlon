const baseUrl = "https://windwebapp.azurewebsites.net/api/Wind";

Vue.createApp({
    data() {
        return {
            posts: [],
            error: null,
            bib:null,
            dataBook: {bib: 0, Name: "", AgeGroup: 0, Bike: 0, Run: 0,},
            deleteMessage: null,
            deleteBib: 0,
            bibToGetBy: 0,
            ErrorMessage: "Non existent",
        }
    },
    methods: {
        async helperGetPosts() {
            try {
                const response = await axios.get(baseUrl)
                this.posts = await response.data
                this.error = null
            } catch (ex) {
                alert(ex)
            }
        },
        async addData(){
          console.table(this.dataBook)
          try{
              response = await axios.post(baseUrl, this.dataBook)
              this.addMessage = "response" + response.status + "" + response.statusText
          } catch(ex) {
              alert(ex.message)
          }
        },
        async deleteData(deleteId) {
          const url = baseUrl + "/" + deleteId
          try {
              response = await axios.delete(url)
              this.deleteMessage = response.status + " " + response.statusText
              this.helperGetPosts()
          } catch (ex) {
              alert(ex)
          }
      },
      async getByBib(bib) {
          const url = baseUrl + "/" + bib
          try {
              const response = await axios.get(url)
              this.posts = await response.data
          } catch (ex) {
              alert(ex)
          }
      },
      async FilteredGetAll(name, time) {
          const newUrl = baseUrl + "?" + (name ? "name=" + name + "&" : "") + (time ? "waitTime=" + time : "")
          const response = await axios.get(newUrl)
          this.posts = await response.data
      }
  
    }
  }).mount("#app")