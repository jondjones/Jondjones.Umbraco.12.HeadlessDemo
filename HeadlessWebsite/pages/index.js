import { fetchItem } from '../utils/umbracoContentDeliveryApi';
import Head from 'next/head';

const Home = (props) => {

    const { name, properties } = props;

    return (
        <>
        <Head>
            <title>{name}</title>
            <meta charset="UTF-8" />
            <meta http-equiv="X-UA-Compatible" content="IE=edge" />
            <meta name="viewport" content="width=device-width,initial-scale=1.0" />
            <meta name="description" content="Jon Page" />
        </Head>
        <div class="hero">
            <div className="container">
                <h1>
                    {name}
                </h1>
                {properties.contentArea}
            </div>
        </div>
        </>
    )
}

export async function getStaticProps() {
    const homepage = await fetchItem('');
    console.log('homepage', homepage);

    return {
        props: {
            name: homepage.name,
            properties: homepage.properties
        }
    }

}

export default Home;
