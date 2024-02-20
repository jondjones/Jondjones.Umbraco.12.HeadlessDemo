
export const getConfig  = () => {

    process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

    const apiKey = process.env.UMBRACO_API_KEY
    const domain = process.env.UMBRACO_DOMAIN;
    const previewEnabled = process.env.UMBRACO_PREVIEW_ENABLED;

    return {
        apiKey,
        domain,
        previewEnabled
    }
}

module.export = {
    getConfig: getConfig
}