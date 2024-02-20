import { fetchItem } from '../utils/umbracoContentDeliveryApi';
import Head from 'next/head';

const Home = (props) => {

    const { name, properties } = props;

    const component = richTextExample();

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
                {/* {<div dangerouslySetInnerHTML={{__html: properties.richText.markup}} />} */}
                {component}
            </div>
        </div>
        </>
    )

    function richTextExample() {
        const component = properties.richText.elements.map(x => {
            return x.elements.map(y => {
                return y.elements.map(z => {
                    console.log(z);
                    return (<div>
                        {z?.text}
                        {z?.attributes?.src}
                    </div>);
                });
            });
        });

        console.log(component);
        return component;
    }
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
