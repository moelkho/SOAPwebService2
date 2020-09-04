
package services;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType">
 *       &lt;sequence>
 *         &lt;element name="SetSearchResult" type="{http://schemas.datacontract.org/2004/07/LecteurServiceWCF}ArrayOfArticle" minOccurs="0"/>
 *       &lt;/sequence>
 *     &lt;/restriction>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "setSearchResult"
})
@XmlRootElement(name = "SetSearchResponse")
public class SetSearchResponse {

    @XmlElementRef(name = "SetSearchResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArticle> setSearchResult;

    /**
     * Gets the value of the setSearchResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArticle }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArticle> getSetSearchResult() {
        return setSearchResult;
    }

    /**
     * Sets the value of the setSearchResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArticle }{@code >}
     *     
     */
    public void setSetSearchResult(JAXBElement<ArrayOfArticle> value) {
        this.setSearchResult = value;
    }

}
